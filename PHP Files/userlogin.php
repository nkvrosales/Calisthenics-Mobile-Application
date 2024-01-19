<?php

include_once('connects.php');

$username = $_GET['uname'];
$password = $_GET['pword'];

$username = trim($username, " ");
$password = trim($password, " ");

$result = mysqli_query($con, "SELECT userID FROM useracc WHERE uname = '$username' AND pword = '$password'");

if (!$row = mysqli_fetch_assoc($result)) {
    echo "Failed!";
} else {
    $userID = $row['userID'];
    echo $userID;
}

mysqli_close($con);
?>