INCLUDE village_globals.ink

->village_aru_main

=== village_aru_main
{
- not state_village_villager_init:
    -> village_default_aru.start
- quest_active == "village_villager":
    {not state_village_villager_aru:
        -> village_villager_aru_init.start
    - else:
        -> village_villager_aru_init.loop
    }
- not state_village_chat_return:
    ~ quest_active = "village_chat"
    {not state_village_chat_aru:
        -> village_chat_aru_init.start
    - else:
        -> village_chat_aru_init.loop
    }
- quest_active == "village_leave":
    {
    - not state_village_leave_aru:
        -> village_leave_aru_init.start
    - else:
        -> village_leave_aru_init.loop
    }
}

=== village_default_aru
= start
You got coins?#speaker:aru #portrait:aru_default #layout:character
~ talked("aru")
-> eol


=== village_villager_aru_init
= start
Heh, fresh eyes! Call me Aru.#speaker:aru #portrait:aru_happy #layout:character
I sell wares, tools, anything!#speaker:aru #portrait:aru_default
I hop from place to place, you might not see me here often, heh.#speaker:aru #portrait:aru_default
    ...#speaker:ragi #portrait:ragi_default
Hey, hey, little fella.#speaker:aru #portrait:aru_default
Would you like to see my wares?#speaker:aru #portrait:aru_default
I'll give special discount just for you, little man.#speaker:aru #portrait:aru_default
I don't usually do this y'know, heh. But I'm in a pretty good mood right now.#speaker:aru #portrait:aru_default
(..?)#speaker:ragi #portrait:ragi_default
* [...]
    -> bread
* [I.. uhh..]
    -> bread

= bread
Heh, speechless there?#speaker:aru #portrait:aru_default
Just wait until you see the things I got my hands on right here.#speaker:aru #portrait:aru_default
(I think I should give the bread now..)#speaker:ragi #portrait:ragi_default
* [(Hand over Coco's bread.)]
Oh, heh, thank you little man. Tell Coco my gratitude.#speaker:aru #portrait:aru_default

~ doneQuest("village_villager_aru")
-> eol

= loop
Nice to meet ya, heh.#speaker:aru #portrait:aru_default #layout:character
~ talked("aru")
-> eol

=== village_chat_aru_init
= start
Need something, heh?#speaker:aru #portrait:aru_default #layout:character
Usually everyone stocks up some beads.#speaker:aru #portrait:aru_default
But it's safe in this village, you might not need them, heh.#speaker:aru #portrait:aru_default
    Beads?#speaker:ragi #portrait:ragi_default
To repel 'em, heh.#speaker:aru #portrait:aru_default
You don't know?#speaker:aru #portrait:aru_default
    ...#speaker:ragi #portrait:ragi_default
Lure them into eating the beads, and poof! They're gone.#speaker:aru #portrait:aru_default
Take some. For your safety, heh.#speaker:aru #portrait:aru_default
    You have obtained beads!#layout:item
Thanks.#speaker:ragi #portrait:ragi_default #layout:character
~ doneQuest("village_chat_aru")
-> eol

= loop
Take care, heh.#speaker:aru #portrait:aru_default #layout:character
~ talked("aru")
-> eol

=== village_leave_aru_init
= start
Heh, leaving so soon?#speaker:aru #portrait:aru_default #layout:character
We might meet again one day.#speaker:aru #portrait:aru_default
~ doneQuest("village_leave_aru")
-> eol

= loop
Be careful.#speaker:aru #portrait:aru_default #layout:character
~ talked("aru")
-> eol