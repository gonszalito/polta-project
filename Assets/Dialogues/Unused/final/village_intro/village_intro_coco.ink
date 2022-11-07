VAR tell_story = 0

=== intro_init ===

= start
Welcome to our village!#speaker:coco #portrait:coco_default #layout:character
I'm Coco! What's your name?#speaker:coco #portrait:coco_happy
    I'm Ragi.#speaker:ragi #portrait:ragi_default
    -> polta
    
= polta
Ragi! Nice to meet you!#speaker:coco #portrait:coco_happy
Are you from.. Polta?#speaker:coco #portrait:coco_frown
    Yup.#speaker:ragi #portrait:ragi_default
Really?! It has been some time since we see another one from Polta!#speaker:coco #portrait:coco_happy
Say, are there any difference between here and Polta?#speaker:coco #portrait:coco_default
    There are.#speaker:ragi #portrait:ragi_default
-> choice

= choice
    {tell_story == 3:
        -> close
    - else:
        #speaker:ragi #portrait:ragi_default
        * [We could never feel the sun directly.]
        -> choice1
        * [choice 2]
        -> choice2
        * [choice 3]
        -> choice3
    }


= choice1   
~ tell_story++
Polta is located underground.#speaker:ragi #portrait:ragi_default
The sunlight is directed through a big dome.#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice

= choice2
~ tell_story++
choice2 content#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice

= choice3
~ tell_story++
choice3 content#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice


= close
That's all I could think of for now.#speaker:ragi #portrait:ragi_default
I feel smarter!#speaker:coco #portrait:coco_happy
-> eol

= eol
-> DONE