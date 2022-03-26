package com.cinema.web.editProfile;

// user update view
@RequestMapping(value="/user/UpdateView", method=RequestMethod.GET)
public String UpdateView(ModelMap model, HttpServletRequest request, HttpServletResponse response)
        {

        String cookieUserId = CookieUtil.getHexValue(request, AUTH_COOKIE_NAME);

        User user = userService.userSelect(cookieUserId);

        model.addAttribute("user", user);

        return "/user/UpdateView";
        }