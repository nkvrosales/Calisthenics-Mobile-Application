<?php

include_once('connects.php');

// Retrieve the latest userID from the table
$query = "SELECT MAX(userInfoID) AS latestUserInfoID FROM userinfo";
$result = mysqli_query($con, $query);
$row = mysqli_fetch_assoc($result);
$latestUserID = $row['latestUserInfoID'];

echo $latestUserInfoID;

?>
