<?php
include_once('connects.php');
$userID = $_GET['userID'];
 

$query = "SELECT MAX(beginnerUP) AS maxBeginnerUP FROM userinfo WHERE userID = $userID ";
$result = mysqli_query($connection, $query);
$row = mysqli_fetch_assoc($result);
$maxBeginnerUP = $row['maxBeginnerUP'];

 

echo $maxBeginnerUP;
?>