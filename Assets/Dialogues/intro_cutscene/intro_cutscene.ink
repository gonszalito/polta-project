INCLUDE ../globals.ink

->init

= init
(Is that a village?)#speaker:ragi #portrait:ragi_default #layout:character
(I should go there.)#speaker:ragi #portrait:ragi_default
~state_intro_cutscene = true
->DONE