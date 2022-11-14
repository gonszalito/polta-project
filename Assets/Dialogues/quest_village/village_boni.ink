INCLUDE village_globals.ink

-> village_boni_main

=== village_boni_main

{
- not state_village_villager_init:
    -> village_default_boni.start
- quest_active == "village_villager":
    {not state_village_villager_boni:
        -> village_villager_boni_init.start
    - else:
        -> village_villager_boni_init.loop
    }
- quest_active == "village_leave":
    {
    - not state_village_leave_boni:
        -> village_leave_boni_init.start
    - else:
        -> village_leave_boni_init.loop
    }
- else:
    -> village_default_boni.start
}

=== village_default_boni
= start
Aaah!#speaker:boni #portrait:boni_default #layout:character
~ talked("boni")
-> eol

=== village_villager_boni_init
= start
Aah!#speaker:boni #portrait:boni_default #layout:character
Y-you scared me!#speaker:boni #portrait:boni_default
Oh.#speaker:boni #portrait:boni_default
Nice to meet you. I'm Boni.#speaker:boni #portrait:boni_default
The others are still out fishing.#speaker:boni #portrait:boni_default
I usually just sit here.#speaker:boni #portrait:boni_default
(I should give the bread now..)#speaker:ragi #portrait:ragi_default
* [(Hand over Coco's bread.)]
Aah! What is that?!#speaker:boni #portrait:boni_default
Oh, a bread? Thanks.#speaker:boni #portrait:boni_default
~ doneQuest("village_villager_boni")
->eol

= loop
I think fishing is not my thing.#speaker:boni #portrait:boni_default #layout:character
Everytime I caught one, it made me- nvm.#speaker:boni #portrait:boni_default
~ talked("boni")
->eol


=== village_leave_boni_init
= start
Aaah!#speaker:boni #portrait:boni_default #layout:character
Oh, you're leaving already?#speaker:boni #portrait:boni_default
Be careful, there might be some.. aaah!#speaker:boni #portrait:boni_default
~ doneQuest("village_leave_boni")
->eol

= loop
Waaah!#speaker:boni #portrait:boni_default #layout:character
~ talked("boni")
->eol