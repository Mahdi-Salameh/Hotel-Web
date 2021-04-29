<?php
    session_start();
    //effacer les données de la session pour effacer $_SESSION['login']
    session_unset();
    session_destroy();
    header("location:login.php");

?>
