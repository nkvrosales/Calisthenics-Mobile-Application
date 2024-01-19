<?php
include_once('connects.php');

// Retrieve input values
$userID = $_GET['userID'];
$name = $_GET['fname'];
$username = $_GET['uname'];
$uage = $_GET['uage'];
$uheight = $_GET['uheight'];
$uweight = $_GET['uweight'];
$pword = $_GET['pword'];
$cpword = $_GET['cpword'];

// Perform basic input validation
if (empty($userID) || empty($name) || empty($username) || empty($uage) || empty($uheight) || empty($uweight) || empty($pword) || empty($cpword)) {
    echo "Please fill in all the fields.";
} elseif ($pword !== $cpword) {
    echo "Password and confirm password do not match.";
} else {
    // All input values are valid, proceed with inserting into the useracc table

    // Prepare the values for insertion (escaping special characters to prevent SQL injection)
    $userID = mysqli_real_escape_string($con, $userID);
    $name = mysqli_real_escape_string($con, $name);
    $username = mysqli_real_escape_string($con, $username);
    $uage = mysqli_real_escape_string($con, $uage);
    $uheight = mysqli_real_escape_string($con, $uheight);
    $uweight = mysqli_real_escape_string($con, $uweight);
    $pword = mysqli_real_escape_string($con, $pword);
    $cpword = mysqli_real_escape_string($con, $cpword);

    // Perform the insertion query
    $query = "INSERT INTO useracc (userID, fname, uname, uage, uheight, uweight, pword, cpword) 
              VALUES ('$userID', '$name', '$username', '$uage', '$uheight', '$uweight', '$pword', '$cpword')";

    if (mysqli_query($con, $query)) {
        echo "Successfully Registered";
    } else {
        echo "Error: " . mysqli_error($con);
    }
}

mysqli_close($con);
?>
