<?php
include_once('connects.php');

 

$userInfoID = $_GET['userInfoID'];
$userID = $_GET['userID'];
$beginnerUP = $_GET['beginnerUP'];
$intermediateUP = $_GET['intermediateUP'];
$advancedUP = $_GET['advancedUP'];

 

// Use prepared statement to prevent SQL injection
$insertQuery = "INSERT INTO userinfo (userInfoID, userID, beginnerUP, intermediateUP, advancedUP) VALUES (?, ?, ?, ?, ?)";
$stmt = mysqli_prepare($connection, $insertQuery);
mysqli_stmt_bind_param($stmt, "iiiii", $userInfoID, $userID, $beginnerUP, $intermediateUP, $advancedUP);
$insertResult = mysqli_stmt_execute($stmt);

 

if ($insertResult) {
    echo "Data inserted into database.";
} else {
    echo "Error inserting data into database: " . mysqli_error($connection);
}
?>