<?php

include_once('connects.php');

// Retrieve the latest userID from the table
$query = "SELECT MAX(userID) AS latestUserID FROM useracc";
$result = mysqli_query($con, $query);
$row = mysqli_fetch_assoc($result);
$latestUserID = $row['latestUserID'];

echo $latestUserID;

?>
