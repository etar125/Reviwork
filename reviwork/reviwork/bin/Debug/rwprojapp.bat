echo off
title TestOS
cls
:x
set /p str=$bash: 
if %str%==info:inf goto inf
goto x
:inf
echo Created on ReviWork (Reversi Worker)
echo By Leva
pause
goto x
