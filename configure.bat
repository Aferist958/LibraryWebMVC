@echo off
copy "%~dp0.env.example" "%~dp0.env.tmp"
powershell -Command "& { [System.IO.File]::WriteAllText('.env', (Get-Content '.env.tmp' -Raw), [System.Text.UTF8Encoding]::new($false)) }"
del .env.tmp
pause