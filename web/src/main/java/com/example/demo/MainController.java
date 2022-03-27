package com.example.demo;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;

@Controller
public class MainController {

    @RequestMapping("/")
    public ModelAndView home(ModelAndView model) {
        model.setViewName("index");

        return model;
    }

    @RequestMapping("/register")
    public ModelAndView reg(ModelAndView model) {
        model.setViewName("register");

        return model;
    }

    @RequestMapping("/login")
    public ModelAndView login(ModelAndView model) {
        model.setViewName("login");

        return model;
    }

    @RequestMapping("/editprofile")
    public ModelAndView eprofile(ModelAndView model) {
        model.setViewName("editprofile");

        return model;
    }
}
