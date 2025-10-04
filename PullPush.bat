@echo off
setlocal enabledelayedexpansion

REM Set ESC variable to ASCII 27
for /F %%A in ('echo prompt $E ^| cmd') do set "ESC=%%A"

REM Use bright cyan (96m) and reset (0m)
echo(%ESC%[96m                                                                                                                      
echo       *******      *                                                     ***** **                                      
echo     *       ***  **                                                   ******  ***                                      
echo    *         **  **                                                 **    *  * ***             **                      
echo    **        *   **                                                *     *  *   ***            **                      
echo     ***          **         **   ****         ****                      *  *     ***            **    ***      ****    
echo    ** ***        **  ***     **    ***  *    * ***  *    ***           ** **      **    ***      **    ***    * **** * 
echo     *** ***      ** * ***    **     ****    *   ****    * ***          ** **      **   * ***     **     ***  **  ****  
echo       *** ***    ***   *     **      **    **    **    *   ***         ** **      **  *   ***    **      ** ****       
echo         *** ***  **   *      **      **    **    **   **    ***        ** **      ** **    ***   **      **   ***      
echo           ** *** **  *       **      **    **    **   ********         ** **      ** ********    **      **     ***    
echo            ** ** ** **       **      **    **    **   *******          *  **      ** *******     **      **       ***  
echo             * *  ******      **      **    **    **   **                  *       *  **          **      *   ****  **  
echo   ***        *   **  ***      *********    *******    ****    *      *****       *   ****    *    *******   * **** *   
echo  *  *********    **   *** *     **** ***   ******      *******      *   *********     *******      *****       ****    
echo *     *****       **   ***            ***  **           *****      *       ****        *****                           
echo *                              *****   *** **                      *                                                   
echo  **                          ********  **  **                       **                                                 
echo                            *      ****     **                                                                                                                                                                                                                                                                                                                    
echo(%ESC%[0m

git pull
echo %ESC%[92mPulled repository%ESC%[0m

git push
echo %ESC%[92mPushed to GitHub%ESC%[0m

echo %ESC%[96mFinished%ESC%[0m

pause
