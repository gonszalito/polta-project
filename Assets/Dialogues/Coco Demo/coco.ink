INCLUDE ../globals.ink
=== coco_talk ===

= start
Welcome to our village!#speaker:coco #portrait:coco_default #layout:character
I'm Coco! What's your name?#speaker:coco #portrait:coco_happy
    *[Tell your name.]#speaker:ragi #portrait:ragi_default
    I'm Ragi.#speaker:ragi #portrait:ragi_default
    -> polta
    

= polta
Ragi! Nice to meet you!#speaker:coco #portrait:coco_happy
Are you from.. Polta?#speaker:coco #portrait:coco_frown
    *[Nods]#speaker:ragi #portrait:ragi_default
    \*nods\*#speaker:ragi #portrait:ragi_default
    ->breadq

= breadq
Ah anyway, could you help me fetch that flour over there?#speaker:coco #portrait:coco_default
    Alright.#speaker:ragi #portrait:ragi_default
Thank you!#speaker:coco #portrait:coco_happy
~ flour_quest_accept = true
-> eol

= eol
-> DONE


=== coco_back ===

= fail
Having trouble finding it? It's beside the bakery.#speaker:coco #portrait:coco_default #layout:character
-> eol

= start
Thanks, you're a lifesaver!#speaker:coco #portrait:coco_happy #layout:character
-> polta_deep

= polta_deep
People from Polta are interesting.#speaker:coco #portrait:coco_default
There was also a man who came here from Polta.#speaker:coco #portrait:coco_default
But he ventured deep in the forest and hasn't came back since..#speaker:coco #portrait:coco_frown
    ...#speaker:ragi #portrait:ragi_default
-> bake

= bake
Oh, it's finished! Here, have a bread.#speaker:coco #portrait:coco_happy
Fresh from the oven.#speaker:coco #portrait:coco_happy
    Thank you.#speaker:ragi #portrait:ragi_default
-> eol

= eol
-> DONE
