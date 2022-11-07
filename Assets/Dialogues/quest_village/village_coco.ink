INCLUDE village_globals.ink

->village_coco_main

=== village_coco_main
{
- not state_village_intro:
    ~ quest_active = "village_intro"
    -> village_intro_coco_init.start
- not state_village_bread:
    ~ quest_active = "village_bread"
    -> village_bread_coco_init.start
- not state_village_villager:
    ~ quest_active = "village_villager"
    -> village_villager_coco_init.start
- not state_village_chat:
    ~ quest_active = "village_chat"
    -> village_chat_coco_init.start
}


=== village_intro_coco_init
= start
Welcome to our village!#speaker:coco #portrait:coco_default #layout:character
I'm Coco! What's your name?#speaker:coco #portrait:coco_happy
    I'm Ragi.#speaker:ragi #portrait:ragi_default
Ragi! Nice to meet you!#speaker:coco #portrait:coco_happy
Are you from.. Polta?#speaker:coco #portrait:coco_sad
    Yup.#speaker:ragi #portrait:ragi_default
Really?! It has been some time since we see another one from Polta!#speaker:coco #portrait:coco_happy
Say, are there any difference between here and Polta?#speaker:coco #portrait:coco_default
    There are.#speaker:ragi #portrait:ragi_default
-> choice

= choice
    {village_intro_choice != 3:
        (What should I tell her...)#speaker:ragi #portrait:ragi_default
        * [We could never feel the sun directly.]
            -> choice1
        * [choice 2]
            -> choice2
        * [choice 3]
            -> choice3
        - else:
            -> close
    }


= choice1
~ village_intro_choice++
Polta is located underground.#speaker:ragi #portrait:ragi_default
The sunlight is directed through a big dome.#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice

= choice2
~ village_intro_choice++
choice2 content#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice

= choice3
~ village_intro_choice++
choice3 content#speaker:ragi #portrait:ragi_default
Amazing!#speaker:coco #portrait:coco_happy
-> choice


= close
That's all I could think of for now.#speaker:ragi #portrait:ragi_default
I feel smarter!#speaker:coco #portrait:coco_happy
~ queueQuest("village_bread")

-> eol


=== village_bread_coco_init

= start
{
- village_bread_talked == false:
    -> help
- village_bread_obtained == false:
    -> hint
- village_bread_obtained == true:
    -> thank
}

= help
Ah by the way, could you help me fetch that flour over there?#speaker:coco #portrait:coco_default #layout:character
    Okay.#speaker:ragi #portrait:ragi_default
Thank you!#speaker:coco #portrait:coco_happy
~ village_bread_talked = true
-> eol

= hint
Having trouble finding it? It's beside the bakery.#speaker:coco #portrait:coco_default #layout:character
-> eol

= thank
Thanks, you're a lifesaver!#speaker:coco #portrait:coco_happy #layout:character
I've been baking since I was young.#speaker:coco #portrait:coco_default
My big bro taught me all about baking!#speaker:coco #portrait:coco_happy
We occasionally went to the city's bakery just to buy recipe.#speaker:coco #portrait:coco_default
I miss him...#speaker:coco #portrait:coco_sad
    ...#speaker:ragi #portrait:ragi_default
Oh, it's finished! Here, have a bread.#speaker:coco #portrait:coco_happy
Fresh from the oven.#speaker:coco #portrait:coco_happy
    Thank you.#speaker:ragi #portrait:ragi_default
~ queueQuest("village_villager")
-> eol



=== village_villager_coco_init
= start
{
- not village_villager_initiated:
    ~ village_villager_initiated = true
    Since you're new here, why don't you introduce yourself to the other villagers?#speaker:coco #portrait:coco_default #layout:character
}
{
- village_villager_talked != amount_npc - 1:
    There are {amount_npc - village_villager_talked - 1} other villagers you haven't met yet!#speaker:coco #portrait:coco_happy #layout:character
    -> eol
- else:
    Enjoy your stay!#speaker:coco #portrait:coco_happy #layout:character
    ~ queueQuest("village_chat")
    -> eol
}

=== village_chat_coco_init
= start
Hey Ragi, how did you come here from Polta?#speaker:coco #portrait:coco_default #layout:character
    My father left me a boat and a guide.#speaker:ragi #portrait:ragi_default
"Left" you?#speaker:coco #portrait:coco_sad
    He went here and has been missing since.#speaker:ragi #portrait:ragi_default
    I'm looking to reunite with him again.#speaker:ragi #portrait:ragi_default
I see...#speaker:coco #portrait:coco_sad
About 2 years ago, there was also a man who came here from Polta.#speaker:coco #portrait:coco_default
The man was really knowledgeable. He helped the village a lot.#speaker:coco #portrait:coco_happy
My brother was very fond of him. They often talk together.#speaker:coco #portrait:coco_default
It might be your father. You look a lot like him.#speaker:coco #portrait:coco_default
    How was his appearance?#speaker:ragi #portrait:ragi_default
Hmm, let me think...#speaker:coco #portrait:coco_default
He's tall, wears glasses, and always bring a book to write.#speaker:coco #portrait:coco_default
    That might be Dad!#speaker:ragi #portrait:ragi_default
Really?!#speaker:coco #portrait:coco_happy
But...#speaker:coco #portrait:coco_sad
He ventured deep into the forest and has never come back since...#speaker:coco #portrait:coco_sad
    ...#speaker:ragi #portrait:ragi_default
    Then I will go to the forest!#speaker:ragi #portrait:ragi_default
-> eol

