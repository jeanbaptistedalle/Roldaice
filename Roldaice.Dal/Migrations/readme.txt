Execute to add EF migration :
Enable-Migration -ProjectName Roldaice.Dal

Execute after model modifications :
Add-Migration -ProjectName Roldaice.Dal <migration_name>

Execute after model modification to add new modification to the current migration : 
Add-Migration -ProjectName Roldaice.Dal <current_migration_name> -Force

Execute to update the database with the last migrations (don't use in release) :
Update-Database -ProjectName Roldaice.Dal

Execute to generate scripts to update the database with the last migrations (use in release) :
Update-Database -ProjectName Roldaice.Dal -Script