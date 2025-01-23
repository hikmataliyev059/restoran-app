﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using restoran_app.DAL.Context;
using restoran_app.Helpers.DTOs.Account;
using restoran_app.Helpers.Enums;
using restoran_app.Models;

namespace restoran_app.Controllers;

public class AccountController : Controller
{
    private readonly AppDbContext _context;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        if (!ModelState.IsValid)
        {
            return View(registerDto);
        }

        AppUser user = new AppUser()
        {
            UserName = registerDto.FullName,
            FullName = registerDto.FullName,
            Email = registerDto.Email
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(registerDto);
        }

        await _userManager.AddToRoleAsync(user, UserRoles.Admin.ToString());
        //await _userManager.AddToRoleAsync(user,UserRoles.Moderator.ToString());
        //await _userManager.AddToRoleAsync(user,UserRoles.Member.ToString());

        return Redirect("Login");
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto, string? ReturnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(loginDto);
        }

        AppUser user = await _userManager.FindByEmailAsync(loginDto.EmailOrUsername)
            ?? await _userManager.FindByNameAsync(loginDto.EmailOrUsername);

        if (user == null)
        {
            ModelState.AddModelError("", "Email or Username is incorrect");
            return View(loginDto);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "check back soon");
            return View(loginDto);
        }

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Email or Username is incorrect");
            return View(loginDto);
        }

        await _signInManager.SignInAsync(user, loginDto.RememberMe);

        if (ReturnUrl != null)
        {
            return Redirect(ReturnUrl);
        }

        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> CreateRole()
    {
        foreach (var item in Enum.GetValues(typeof(UserRoles)))
        {
            if (!await _roleManager.RoleExistsAsync(item.ToString()))
            {
                await _roleManager.CreateAsync(new IdentityRole(item.ToString()));
            }
        }

        return RedirectToAction("Index", "Home");
    }
}
