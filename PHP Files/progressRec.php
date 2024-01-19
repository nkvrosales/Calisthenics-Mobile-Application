<?php 

include_once('connects.php');
$userInfoID = $_GET['userInfoID'];
$userID = $_GET['userID'];
$beginnerUP =  $_GET['beginnerUP'];
$intermediateUP = $_GET['intermediateUP'];
$advancedUP = $_GET['advancedUP'];


$result = mysqli_query($con,"INSERT INTO userinfo (userInfoID,UserID,beginnerUP,intermediateUP,advancedUP) VALUES('$userInfoID','$userID','$beginnerUP','$intermediateUP','$advancedUP')");
echo "Successfully Registered";

?>