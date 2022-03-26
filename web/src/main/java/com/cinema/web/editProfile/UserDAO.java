package com.cinema.web.editProfile;

// edit user information
public void userUpdate(User user)throws Exception;

@Override
public void userUpdate(User user) throws Exception {
        sql.update("userMapper.userUpdate", user);
        }
        // parameters in the user to userMapper namespace in userMapper.xml
        // add parameters in query named userUpdate