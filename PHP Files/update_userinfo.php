<?php
include_once('connects.php');

 

$userID = $_GET['userID'];
$beginnerUP = $_GET['beginnerUP'];
$intermediateUP = $_GET['intermediateUP'];
$advancedUP = $_GET['advancedUP'];

 

// Use prepared statement to prevent SQL injection
$updateQuery = "UPDATE userinfo SET beginnerUP = ?, intermediateUP = ?, advancedUP = ? WHERE userID = ?";
$stmt = mysqli_prepare($connection, $updateQuery);
mysqli_stmt_bind_param($stmt, "iiii", $beginnerUP, $intermediateUP, $advancedUP, $userID);
$updateResult = mysqli_stmt_execute($stmt);

 

if ($updateResult) {
    echo "Database updated successfully.";
} else {
    echo "Error updating database: " . mysqli_error($connection);
}
?>