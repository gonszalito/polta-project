INCLUDE village_globals.ink


{
- not state_village_intro:
    ~ quest_active = "village_intro"
    -> village_intro_coco_init.start
- not state_village_bread_return:
    ~ quest_active = "village_bread"
    -> village_bread_coco_init.start
- not state_village_villager_return:
    ~ quest_active = "village_villager"
    -> village_villager_coco_init.start
- not state_village_chat_return:
    ~ quest_active = "village_chat"
    {not state_village_chat_coco:
        -> village_chat_coco_init.start
    - else:
        -> village_chat_coco_init.loop
    }
- quest_active == "village_leave":
    {
    - not state_village_leave_coco:
        -> village_leave_coco_init.start
    - else:
        -> village_leave_coco_init.loop
    }
- else:
    -> village_default_coco.loop
}

=== village_default_coco
= start
I love breads!#speaker:coco #portrait:coco_happy #layout:character
-> eol

= loop
I love breads!#speaker:coco #portrait:coco_happy #layout:character
-> eol


=== village_intro_coco_init
= start
Welcome to our village!#speaker:coco #portrait:coco_default #layout:character
I'm Coco! What's your name?#speaker:coco #portrait:coco_happy
    I'm Ragi.#speaker:ragi #portrait:ragi_default
Ragi! Nice to meet you!#speaker:coco #portrait:coco_happy
You don't look like you're from around here.#speaker:coco #portrait:coco_default
Could it be.. you're from Polta?#speaker:coco #portrait:coco_sad
    Yes.#speaker:ragi #portrait:ragi_default
Really?! It has been some time since we see another one from Polta!#speaker:coco #portrait:coco_happy
How did you come here?#speaker:coco #portrait:coco_default
-> choice

= choice
    (How did I travel?)#speaker:ragi #portrait:ragi_default
    * [I sailed across the sea]
    -> choice1
    * [I used a raft]
    -> choice1

= choice1
And suddenly I woke up at the seashore nearby.#speaker:ragi #portrait:ragi_default
-> close

= choice2
I not really sure what happened back then.#speaker:ragi #portrait:ragi_default
-> close


= close
That's scary!#speaker:coco #portrait:coco_sad
What matters is that you're still safe and sound.#speaker:coco #portrait:coco_happy
~ doneQuest("village_intro")

-> eol


=== village_bread_coco_init

= start
{
- not state_village_bread_init:
    -> help
- not state_village_bread_flour:
    -> hint
- not state_village_bread_return:
    -> thank
}

= help
You can stay here for a while if you want! It's safe and-#speaker:coco #portrait:coco_default #layout:character
Ah! That's right! I need to start baking a new batch right now!!#speaker:coco #portrait:coco_happy
    ...#speaker:ragi #portrait:ragi_default
Oh, we are short on flour to make our dough.#speaker:coco #portrait:coco_sad
Could you help me fetch a pack of flour?#speaker:coco #portrait:coco_default
    Sure.#speaker:ragi #portrait:ragi_default
Thank you! It's right beside the bakery, near the pile of boxes.#speaker:coco #portrait:coco_happy
~ doneQuest("village_bread_init")
-> eol

= hint
Having trouble finding it? It's beside the bakery.#speaker:coco #portrait:coco_default #layout:character
~ talked("coco")
-> eol

= thank
Perfect! Thank you so much!#speaker:coco #portrait:coco_happy #layout:character
I've been baking since I was young.#speaker:coco #portrait:coco_default
My big bro taught me all about baking!#speaker:coco #portrait:coco_happy
I miss him...#speaker:coco #portrait:coco_sad
    ...#speaker:ragi #portrait:ragi_default
    (I wonder where he is.)#speaker:ragi #portrait:ragi_default
It's done!#speaker:coco #portrait:coco_happy
Here, you can have some.#speaker:coco #portrait:coco_default
Fresh bread from the oven! Hope you like it.#speaker:coco #portrait:coco_happy
~ doneQuest("village_bread_return")
-> eol



=== village_villager_coco_init
= start
{
- not state_village_villager_init:
    -> init
- not state_village_villager_all:
    -> helper
- not state_village_villager_return:
    -> finish
}

= init
Since you're here, why don't you introduce yourself to the others?#speaker:coco #portrait:coco_happy #layout:character
It's safe in the village, so feel free to roam around.#speaker:coco #portrait:coco_default
Oh and while you're at it, you could give the bread that I have also prepared for the others too!#speaker:coco #portrait:coco_happy
What do you think? Will you help me once more?#speaker:coco #portrait:coco_default
    Okay.#speaker:ragi #portrait:ragi_default
Thanks a bunch!! It's a pleasure to have you here in the village. See you later!#speaker:coco #portrait:coco_happy
~ doneQuest("village_villager_init")
-> eol

= helper
Oh, you still have {amount_npc - village_villager_talked} bread left.#speaker:coco #portrait:coco_default #layout:character
Make sure to give them all out, alright?#speaker:coco #portrait:coco_happy
~ talked("coco")
-> eol

= finish
Hey, you're back!#speaker:coco #portrait:coco_happy #layout:character
How was it? The people here are nice aren't they?#speaker:coco #portrait:coco_default
(How was it?)#speaker:ragi #portrait:ragi_default
* [It was nice.]
-> close
* [It was something.]
-> close

= close
I hope you enjoy every moment of it!#speaker:coco #portrait:coco_happy
You may walk around the village and take a break.#speaker:coco #portrait:coco_default
See you around!#speaker:coco #portrait:coco_happy
~ doneQuest("village_villager_return")
-> eol

=== village_chat_coco_init
= start
Hey Ragi, why did you come here from Polta?#speaker:coco #portrait:coco_default #layout:character
    My father went here and has been missing since.#speaker:ragi #portrait:ragi_default
    I'm looking to reunite with him again.#speaker:ragi #portrait:ragi_default
I see...#speaker:coco #portrait:coco_frown
Let me know if I could help in any way!#speaker:coco #portrait:coco_happy
~ doneQuest("village_chat_coco")
-> eol

= loop
I hope all the best for you!#speaker:coco #portrait:coco_happy
~ talked("coco")
-> eol

=== village_leave_coco_init
= start
Oh... you're leaving the village?#speaker:coco #portrait:coco_frown #layout: character
But we've just met...#speaker:coco #portrait:coco_sad
It's dangerous to go alone! Take this.#speaker:coco #portrait:coco_default
You have obtained Coco's signature bread.#layout:item
    Thank you.#speaker:ragi #portrait:ragi_default #layout:character
Be careful out there!#speaker:coco #portrait:coco_happy
~ doneQuest("village_leave_coco")
-> eol

= loop
Come back soon!#speaker:coco #portrait:coco_happy #layout:character
~ talked("coco")
-> eol
