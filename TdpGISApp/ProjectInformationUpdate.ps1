
Write-Output ('##vso[task.setvariable variable=RevisonVersion]{0}' -f $(Get-Date -Format yyyyMMdd))

$files = Get-ChildItem $Env:BUILD_SOURCESDIRECTORY -Recurse -Include appsettings.json | where {! $_.PSIsContainer}


$TagHolder = "Unknown-BuiltTag"

$KeyHolder = "--key--"

$KeyValue = $ConnectionKey

Write-Output "Number of files: $files.Length"

foreach ($file in $files) {
    
    $filecontent = Get-Content($file)
   
    $filecontent -replace $TagHolder, $Env:BUILD_BUILDNUMBER | Out-File $file

    $filecontent -replace $KeyHolder, $KeyValue | Out-File $file

    Write-Output "$file.FullName - Built Tag is updated"
}

foreach ($file in $files) {
    
    $filecontent = Get-Content($file)
     
    $filecontent -replace $KeyHolder, $KeyValue | Out-File $file

    Write-Output "$file.FullName - Update the key $(KeyValue)"
}



