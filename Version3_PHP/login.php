<!DOCTYPE html>
<html lang="en" dir="ltr">
    <head>
        <meta charset="utf-8">
        <title></title>
    </head>
    <body>
        <?php
            require_once("menu.php");
            //Test si l'utilisateur est deja connecte
            if(isset($_SESSION['login']))
                header("location:home.php");

            if(isset($_POST['btnLogin']))
            {
                $login=$_POST['txtLogin'];
                $pwd=$_POST['txtPwd'];
                if(isset($_POST['chkMemo']))
                {
                    setcookie("login","$login",mktime(12,0,0,12,31,2020));
                    setcookie("pwd","$pwd",mktime(12,0,0,12,31,2020));
                }
                require_once("connexion.php");
                $sql="select login,password from client where login=$login and password='$pwd'";
                $res=mysqli_query($link,$sql);
                if(mysqli_num_rows($res) == 1)
                {
                    $ligne=mysqli_fetch_array($res);
                    $_SESSION['login']=$login;
                    header("location:home.php");
                }
                else
                    echo "<p align='center'><b>Login ou Mot de passe Incorrects</b></p>";
            }
            else if(isset($_COOKIE['login'],$_COOKIE['pwd']))
            {
                $login=$_COOKIE['login'];
                $pwd=$_COOKIE['pwd'];
            }
            else
                $login = $pwd = "";
        ?>
        <form method="post">
            <br>
            <table align="center" border="3" rules="none">
                <tr>
                    <td>Login: </td><td><input type="text" name="txtLogin" value="<?php echo $login; ?>"></td>
                </tr>
                <tr>
                    <td>Password: </td><td><input type="password" name="txtPwd" value="<?php echo $pwd; ?>"></td>
                </tr>
                <tr>
                    <td><input type="submit" name="btnLogin" value="Login"></td><td></td>
                </tr>
                <tr>
                    <td colspan="2"><input type="checkbox" name="chkMemo">Mémoriser Login et Mot de Passe</td>
                </tr>
            </table>
        </form>
    </body>
</html>
