<!DOCTYPE html>
<html lang="en" dir="ltr">
    <head>
        <meta charset="utf-8">
        <title></title>
    </head>
    <body>
        <?php
            require_once("menu.php");
            //Test si l'utilisateur est connecte
            if(!isset($_SESSION['login']))
                header("location:login.php");
        ?>
        <br>
        <table align="center" border="3">
            <tr>
                <th>Numéro</th><th>Date d'arrivée</th><th>Date de départ</th><th>Totale</th>
            </tr>
            <?php
                require_once("connexion.php");
                $sql="select numeroChambre,dateArrivee,dateDepart,totale from reservation where loginClient={$_SESSION['login']} order by dateArrivee desc";
                $res=mysqli_query($link,$sql);
                if(mysqli_num_rows($res) > 0)
                    while($ligne=mysqli_fetch_array($res))
                        echo "<tr>
                                <td>$ligne[0]</td><td>$ligne[1]</td><td>$ligne[2]</td><td>$ligne[3]</td>
                              </tr>";
            ?>
        </table>
    </body>
</html>
