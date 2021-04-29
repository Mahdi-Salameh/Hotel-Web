<?php
    session_start();
    //Test si l'utilisateur est connecte
    if(isset($_SESSION['login']))
        $v=(str_repeat('&nbsp',6))."<a href='historique.php'>Historique</a>".(str_repeat('&nbsp',6))."<a href='logout.php'>Logout</a>";
    else
        $v=(str_repeat('&nbsp',6))."<a href='login.php'>Login</a>";
    echo "<table border='3' width='100%' height='50'>
        <tr>
            <td align='center'><a href='home.php'>Home</a>$v</td>
        </tr>
    </table>";
 ?>
