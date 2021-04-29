<?php
    session_start();
    //Test si l'utilisateur est connecte
    if(isset($_SESSION['login']))
    {
        //Test si tous les données sont disponible
        if(isset($_GET['numero'],$_SESSION['dateArrivee'],$_SESSION['dateDepart'],$_SESSION['nbJours']))
        {
            require_once("connexion.php");
            $sql="select tarif from chambre,categorie where numero={$_GET['numero']} and id=idCategorie";
            $res=mysqli_query($link,$sql);
            //Test pour être sûre que le numéro de chambre est correct
            //peut etre l'utilisateur a ecrit manuellement dans URL le numero chambre
            if(mysqli_num_rows($res) == 1)
            {
                $ligne=mysqli_fetch_array($res);
                $totale=$_SESSION['nbJours'] * $ligne[0];//calculer totale=nbJours * tarif
                $sql="insert into reservation
                values({$_GET['numero']},{$_SESSION['login']},'{$_SESSION['dateArrivee']}','{$_SESSION['dateDepart']}',$totale)";
                mysqli_query($link,$sql);
                //effacer les données de la session pour éviter les réservations inappropriées
                //peut etre l'utilisateur a ecrit manuellement dans URL le numero de chambre
                unset($_SESSION['dateArrivee'],$_SESSION['dateDepart'],$_SESSION['nbJours']);
                if(mysqli_affected_rows($link) > 0)
                    header("location:historique.php");
            }
            else
                header("location:home.php");
        }
        else
            header("location:home.php");
    }
    else
        header("location:login.php");
?>
