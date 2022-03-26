package com.cinema.web.editProfile;

// edit profile
public int userUpdate(User user){
        int count=0;

        try{
        count=userDao.userUpdate(user);
        }

        catch(Exception e){
        logger.error("[UserService] userUpdate Exception",e);
        }

        return count;
        }