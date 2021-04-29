<?php
    $link=mysqli_connect("localhost","root","","hotel");
    //$link=mysqli_connect("localhost","user","user","Hotel");//avec username et password
    if($link == false)
        die("Impossible de se connecter au MYSQL a cause de:".mysqli_connect_error());
 ?>
