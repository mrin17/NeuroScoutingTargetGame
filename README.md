# NeuroScoutingTargetGame
A simple, reaction time game. When you see the target, press the space bar. 

Rules of the game:
A pitcher is throwing baseballs at you. There is an arrow on the baseball. You are shown a rotated arrow at the start of each trial. Press space when you see a baseball with the correct arrow rotation on it. The baseballs grow larger as time goes by and they each have a random velocity. You can specify the number of trials at the start of the game. At the end of the game, the program tells you your score, and displays when and where you hit or didn't hit each baseball.

Scoring:
Not hitting an incorrect baseball : 1 pt
Not hitting a correct basebal : -8pts
Hitting a correct baseball : 8pts * (2 seconds - time it took you to press space) / 2 seconds
Hitting an incorrect baseball : -1pts * (2 seconds - time it took you to press space) / 2 seconds

The code: 
I organized Scenes, Images, Scripts, and Prefabs into their own folders. At the beginning of the game, you choose the number of trials, which is tracked by an object with scrTrialNum on it. This object is persistent throughout rooms. Once you confirm, scrBaseballController takes it from here. This script shows you a random angled baseball (multiple of 45) for 2 seconds, and then proceeds to create 6 baseballs on the specified timer system. The baseballs move themselves. scrBaseballController tracks when you press space and scores the baseball accordingly. If you do not press space, the baseball tells the scrBaseballController to score this baseball (when it is disabled). Each baseball tracks its size, rotation, and location when it is scored. They also track if the score got positive or negative points. After each trial, scrBaseballController resets most of the variables (excluding score) and starts again. Once the game is over, scrBaseballController tells all the baseballs to display themselves again, and when they do, they should use the tracked values when they were scored. This gives a visual representation of the player data. Also displayed is max score with a comparison to your score.
