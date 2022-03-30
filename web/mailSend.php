<!-- <?php
include "server.php";
$to      = $email; // Send email to our user
$subject = 'Signup | Verification'; // Give the email a subject 
$message = '
  
Thanks for signing up!
Your account has been created, you can login with the following credentials after you have activated your account by pressing the url below.
  
------------------------
Username: '.$email.'
Password: '.$password.'
------------------------
  
Please click this link to activate your account:
http://www.yourwebsite.com/verify.php?email='.$email.'&hash='.$hash.'
//$hash = md5( rand(0,1000) ); this has function basically make the encryption im unsure where to put it exactly.
'; // Our message above including the link
                      
$headers = 'From:noreply@yourwebsite.com' . "\r\n"; // Set from headers
mail($to, $subject, $message, $headers); // Send our email -->
