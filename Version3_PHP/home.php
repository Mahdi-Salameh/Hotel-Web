<!DOCTYPE html>
<html lang="en" dir="ltr">
    <head>
        <meta charset="utf-8">
        <title></title>
    </head>
    <body>
        <?php
            require_once("menu.php");
            require_once("connexion.php");

            if(isset($_POST['txtArrivee']))
            {
                $v1=$_POST['txtArrivee'];
                $v2=$_POST['txtDepart'];
            }
            else
                $v1 = $v2 ="";

        ?>
        <br>

        <form  method="post">
            <table align="center" border="3" rules="none">
                <tr>
                    <td>Date d’arrivée: </td><td><input type="text" name="txtArrivee" placeholder="yyyy-mm-dd" value="<?php echo $v1; ?>"></td>
                </tr>
                <tr>
                    <td>Date de départ: </td><td><input type="text" name="txtDepart" placeholder="yyyy-mm-dd" value="<?php echo $v2; ?>"></td>
                </tr>
                <tr>
                    <td>Chambre:</td><td><select name="cmbCategorie">
                    <!-- Ajouter un option "All" pour afficher les chambres selon toutes les categories -->
                                            <option value="0">All</option>
                        <?php

                            $sql="select id,libelle from categorie";
                            $res=mysqli_query($link,$sql);
                            if(mysqli_num_rows($res) > 0)
                                while($ligne=mysqli_fetch_array($res))
                                {
                                    if(isset($_POST['cmbCategorie']) && $ligne[0]==$_POST['cmbCategorie'])
                                        $v="selected";
                                    else
                                        $v="";

                                    echo "<option value='$ligne[0]' $v>$ligne[1]</option>";
                                }

                        ?>
                    </select></td>
                </tr>
                <tr>
                    <td></td><td><input type="submit" name="btnRechercher" value="Rechercher"></td>
                </tr>
            </table>
        </form>
        <br>

        <?php
            //Afficher le tableau
            if(isset($_POST['btnRechercher']))
            {
                $date1=explode("-",$_POST['txtArrivee']);
                $date2=explode("-",$_POST['txtDepart']);

                //test si la date est dans la format convenable (3 parties yyyy-mm-dd)
                if(count($date1) != 3 || count($date2) != 3)
                    die("<script>alert('Entrer des dates correct svp.')</script>");

                //else test si chaque partie est numerique
                //pour eviter les erreur quand on utilise checkdate();
                for ($i=0; $i < 3; $i++)
                {
                    if(!is_numeric($date1[$i]) || !is_numeric($date2[$i]))
                        die("<script>alert('Entrer des dates correct svp.')</script>");
                }

                //else test si c'est un date correct
                if(!checkdate($date1[1],$date1[2],$date1[0]) || !checkdate($date2[1],$date2[2],$date2[0]))
                    die("<script>alert('Entrer des dates correct svp.')</script>");

                //si date d'arrivée est passe
                /*if( time() < mktime(0,0,0,$date1[1],$date1[2],$date1[0]))
                    die("<script>alert('Date d'arrivée est passé!')</script>");*/

                //calculer le nombre de jours entre le date d'arrivée et date de depart
                $nbJours=(mktime(0,0,0,$date2[1],$date2[2],$date2[0]) - mktime(0,0,0,$date1[1],$date1[2],$date1[0]))/(60*60*24);

                if($nbJours < 0) //si dateArrivee < dateDepart
                    die("<script>alert('Dates de depart ou d\'arrivée Incorrects!')</script>");
                else if($nbJours == 0)//si dateArrivee et dateDepart dans la même jour
                    $nbJours=1;

                //Date est correct maintenant
                echo "<table align='center' border='3'>
                     <tr>
                        <th>Numéro</th><th>Etage</th><th>Type</th><th>Tarif</th><th>Reservation</th>
                     </tr>";
                //Test pour savoir si l'utilisateur choisit l'option "All"
                //si non alors afficher les chambre selon le categorie choisisse
                if($_POST['cmbCategorie'] == 0)
                    $v="";
                else
                    $v="and id={$_POST['cmbCategorie']}";
                //Requet sql pour afficher les chambre disponible entre les dates données
                $sql="select numero,etage,libelle,tarif from chambre,categorie
                        where id=idCategorie $v
                        and numero not in (select numeroChambre from reservation,chambre
												where numeroChambre=numero
												and (      ( '{$_POST['txtArrivee']}' BETWEEN dateArrivee and dateDepart )
														or ( '{$_POST['txtDepart']}' BETWEEN dateArrivee and dateDepart )
         												or ( '{$_POST['txtArrivee']}' < dateArrivee and '{$_POST['txtDepart']}' > dateDepart )
													)
                                            ) order by numero";
                $res=mysqli_query($link,$sql);
                if(mysqli_num_rows($res) > 0)
                    while($ligne=mysqli_fetch_array($res))
                    {
                        echo "<tr>
                             <td>$ligne[0]</td><td>$ligne[1]</td><td>$ligne[2]</td><td>$ligne[3]</td>
                                <td><a href='reservation.php?numero=$ligne[0]'>Reserver</a></td>
                             </tr>";
                    }
                echo "</table>";

                //sauvgarder Dates et nbJours pour utiliser dans la page de reservation
                $_SESSION['dateArrivee']=$_POST['txtArrivee'];
                $_SESSION['dateDepart']=$_POST['txtDepart'];
                $_SESSION['nbJours']=$nbJours;
            }
        ?>
    </body>
</html>
