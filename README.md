# Alien-Hunter
Game prototype made by Eric Callahan. To be developed by the Software, Web, and Game Development Club of Eastern Michigan University.

This game is a work in progress. I spent the past 3 months working on the player controller as well as the enemy AI, all of which are buggy and unfinished. Listed below are all of the game's bugs which must be fixed in order to fulfill the desired player experience. For most of the code, I had assistance from youtube tutorials, which I will I provide per bullet point. If at any point yoou need assistance, such another explanation on a glitch, or have any siggestions, if you need *anything* from me, just reach out to me on Discord via the SGW DEVS server or @Eman59#9311. I'm available from 12 PM EST to 3 AM EST approximatelly, which is pretty much when I'm awake.

---------------------------------------------Game Summary, Gameplay Elements, and Aesthetic ---------------------------------------

Before we talk bugs, let me explain what this game is. This is a 2D hack-and-slash / run-n-gun action platformer. The gist of the story is that aliens are invading the solar system and you alone have to take them out. Each level is on a different planet, as well as Earth's moon, and a coupole final levels on the alien homeworld (total about 11-13 stages). The levels are mostly linear with some exploration elements to find goodies. The gameplay is all about combat. You start off with your lightsaber-sword-thing as well as your rapid-fire gun and slice up some aliens. The player canm double jump, dash, and wall climb, for extra movement. After each level, the player unlocks a new weapon or ammo type to use, akin to Mega Man. The player can open up a weapon wheel to select their melee weapon and ammot type (you start with 1 melee weapon and 1 ammo type, and unlock 4 more of each, so 5 weapons to choose per the two weapon wheels, controlled by the left and right stick on a gamepad). There will also be a Stage Select in similar fashion to Mega Man. Your space ship will be a small hub where you can buy upgrades, as well as access a training room. There will also be story related cutscenes here after completing some stages.

The art style is gonna be edgy, cartoony, and somewhat futurisitc. The music will be upbeat, featuring rock, techno, and other music styles. The atmoshpere should feel grim and desolate, while also keeping the game flow fast with the music. As for art, I plan on doing most of the characters and their animations, but I would like assistance with levels and environments. I have high ambitions for this project and I don't think this is something we can complete in one semester (especially this semester, given the circumstances), but programming is a huge weakness of mine and I will appreciate any and all help I can get.

Lastly I have created concpets for levels, weapons, and bosses, but I have nothing to show right now. If you would like to know what else I have in mind from a creative standpoint, don't hesitate to contact me.

Level select video: https://www.youtube.com/watch?v=jBnaFqIZZDw


----- Current Game Controls --------

A or Left Arrow, move left.

D or Right Arrow, move right.

Space to jump.

Left Mouse (Fire1) to attack.

Left Shift to Dash.

I would like to intergrate these to a gamepad (example, PS4 controller) at some point.


-----------------------------------------------PLAYER CONTROLLER BUGS/THINGS TO FIX--------------------------------------------------

Main Player Controller Scrpit (featuring movement, jumping, and GroundChecks) video:
https://www.youtube.com/watch?v=44djqUTg2Sg&t
No bugs here. Player moves fine.

Camera Boundaries video: https://www.youtube.com/watch?v=05VX2N9_2_4
In scene view, there is a yellow rectangle. This represents the current camera boundaries. This can be adjusted within the Inspector by adjusting the values in the Camera Follow 2D Script. No bugs here.

Camera Follow video: https://www.youtube.com/watch?v=7JjzhhC06xw
The speed and offset at which the camera follows the player. Located in the Camera Follow 2D Script.No bugs here.

----- Jumping -----

Bug location: PlayerController Script

Jump video: https://www.youtube.com/watch?v=j111eKN8sJw

--- The player jump is not working properly. The Can Jump boolean is not activated at the correct times. The intention is for the player to ascend for as long as the jump key is held, without exceeding the maximum jump value. The same goes for the double jump. If the player walks off a platform and is in the falling state, they should have access to a double jump.


----- Dashing -----

Bug Location: Player Controller Script

Dash Video: https://www.youtube.com/watch?v=I4Ja5Ar63Pw

--- The player dash ability must function identically to how it is performed in Mega Man X on the SNES. The issue here is that if the player presses the Dash key while standing still, the dash animation will play but the player will not move. The player should recieve a small forward boost if no direction is held and the Dash key is pressed.

--- If the player performs a dash while moving and jumps, they should carry the Dash speed throughout the duration of the jump and double jump. However, the player's speed returns to normal while in mid-air during a dash jump, slowing down the player in mid-air.

---- If the player dashes in midair, they should recieve a horizontal boost of momentum while also keeping the same Y value (just fly in the air, essentially). However, noting happens if the dash key is pressed while in mid-air.
   
 
----- Attacking with sword -----

Bug Location: Player Controller Script

Melee attack video: https://www.youtube.com/watch?v=KamdeKs6eKo

--- The intention here is to have a "1-2-3" attack, where if the Attack key is pressed 3 times in succession, the player would unleash 3 consecutive sowrd swings, with 3 different animations. The AttackHitbox would be instantied and un-instantied in this order: Attack key pressed, play animation, activate hitbox after x amount of frames after frame x of animation, (but only hits the enemy once), deactivate hitbox after frame x of animation, finish animation. If attack is pressed again during attack 1, attack 2 would begin in the same order. Attack 3 would begin after attack 2, but this is a "multi-hit" hitbox that can hit enemies repeatedly for x amount of times. My theory is that this hitbox can be activatd and deactivatd several times thorughout the attack 3 animation. (For reference, look up Mega Man X5 or X6 gameplay of Zero, on the PlayStation 1). I cannot set this up porperly, so he code is currently commented out and only attack 1 plays if attack is pressed.

--- If the player presses attack in midair, they perform a spinning midair attack. This is mostly functioning as intended but needs some polishing. Firstly, the attack should be cancelled if the player comes in contact with the ground. Right now the attack continues to play until the "attack in mid-air" function is completed. Lastly, this attack should be a multi-hit hitbox similar to the grounded Attack 3, but right now it is a single hit.

----- Wall climbing -----

Wall interactions video: https://www.youtube.com/watch?v=YeHhVlDMVKY
(note: the player will not wall climb, they will wall slide, wall jump, and dash jump from walls.)

This feature is not added yet but I would like it to be included in the final game. Look up Wall Climbing from Mega Man X on the SNES. I essentially want to use that mechanic in the player controller. Wall climbing sprites are located in the graphics folder outside of the unity file.


----- Shooting -----

This feature is also not currently added. Look up gameplay from Contra 3: The Alien Wars on the SNES. I would like to incorporate 8-directional shooting into the game via the player controller. Sprites for this are not yet made.


----- Player taking damage -----

Sprites are located in the same folder as wall climbing. This is not yet intergrated as I have not yet given the enemies hitboxes on their attacks.




----------------------------------------------ENEMIES AND UI-------------------------------------------------

There are two enemies I have created, Aliens 1 and 2. Alien 1 is a gunner and Alien 2 has a sword. If the player touches ANY enemy in the game, the player will take damage on collision. Alien 1 should run on-screen, stop within x distance of the player, and begin shooting. The bullets should be shot towards the player's location and deal damage to the player on contact. Alien 2 will feature agro AI (or raycast, or something close to it). It will run towards the player, and when within attack range, will play the attack animation and instantiate the attack hitbox, which can damage the player. The functions listed above do not work properly.

Alien 1 and 2 share the Alien Controller script, which is responsible for the enemy health. It works fine for Alien 2 but not Alien 1. The aliens have similar code for their movements located in their scripts (Alien1Shoot and Alien2Agro) which doesn not work properly. They essentially run towards the player but never stop. Also, Alien 2's health system is working properly. When damaged, he flashes white. Eventually he despawns.

Alien 1

Shooting code video: https://www.youtube.com/watch?v=_Z1t7MNk0c4

Bug Loctions: Alien1Shoot and Alien1Projectile Scripts. Perhaps in Alien Controller as well.

--- He despawns after a few seconds. I don't know why.

--- I wrote a script named Alien1Shoot, which is reponsible for spawining the bullet and deleting itself after coming in contact with the player (and going off-screen perhaps). The code currently does not work and does not instantie the placeholder yellow circle graphic named "enemybullet".

-- The alien runs towards the player but does not stop. Then he disappears as stated before.

Alien 2

Bug Location: Alien2Agro Script.

Agro video: https://www.youtube.com/watch?v=nEYA3hzZHJ0

Raycast video: https://www.youtube.com/watch?v=2VX8uD_xUlM

--- Not too many issues with this one. His attack function does not work when he is close to the player, nor does he stop in place. He continously moves towards the player forever.

UI

Health video: 

https://www.youtube.com/watch?v=3uyolYVsiWc

Bug Location: Canvas object in Unity Editor.

--- The only UI I have integrated so far is the player health bar. The code is in the Health script. The health bar does display in the correct area but the health tick (the orange rectangles that actually reprtesent the player's health) do not appear at all in the Game View. Also, the health bar is an early version and I would like to make a better one later.


------------------------------Conclusion---------------------------

Hopefully I've reported every bug in the game. If there are more, contact me if you want, but try your best to fix the for me please! Again, any questions, comments, concerns, DM me on discord, or email me at ecallah3@emich.edu. Discord is reommended since I can contact you faster there. Once the semester starts I will get to work on creating more enemy sprites, boss sprites, animations, and level design. Good luck this semester, everyone. Remember to put your classes first and wear a mask :)
