param($installPath, $toolsPath, $package, $project)


function Replace-TemporaryFiles($parent, $fileExtension)
{
	if($parent)
	{
		$parent.ProjectItems | ForEach-Object { 
		if($_.Name.EndsWith($fileExtension)){
			Copy-Item $_.FileNames(0) $_.FileNames(0).Replace($fileExtension,"") -force
			$_.Delete() 
		}
	}
	}
}
#Replace Error File
$views = $project.ProjectItems | Where-Object { $_.Name -eq "Views"}
$sharedViews = $views.ProjectItems | Where-Object { $_.Name -eq "Shared"}

$errors = $project.ProjectItems | Where-Object { $_.Name -eq "EnhancedErrorPage"}
$models = $errors.ProjectItems | Where-Object { $_.Name -eq "Models"}

Replace-TemporaryFiles $sharedViews ".eep.cshtml"
Replace-TemporaryFiles $errors ".eep.cs"
Replace-TemporaryFiles $models ".eep.cs"
