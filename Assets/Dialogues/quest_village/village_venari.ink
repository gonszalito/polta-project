INCLUDE village_globals.ink

->village_venari_main

=== village_venari_main

{
- not state_village_villager_init:
    -> village_default_venari.start
- quest_active == "village_villager":
    {not state_village_villager_venari:
        -> village_villager_venari_init.start
    - else:
        -> village_villager_venari_init.loop
    }
- not state_village_chat_return:
    ~ quest_active = "village_chat"
    {
    - state_village_chat_all:
        -> village_chat_venari_return.start
    - not state_village_chat_venari:
        -> village_chat_venari_init.start
    - else:
        -> village_chat_venari_init.loop
    }
- quest_active == "village_leave":
    {
    - not state_village_leave_venari:
        -> village_leave_venari_init.start
    - else:
        -> village_leave_venari_init.loop
    }
- else:
    -> village_leave_venari_init.loop
}

=== village_default_venari
= start
Hmm?#speaker:venari #portrait:venari_default #layout:character 
~ talked("venari")
-> eol

=== village_villager_venari_init
= start
Hm?#speaker:venari #portrait:venari_default #layout:character
I've never seen you before.#speaker:venari #portrait:venari_default
Another Polta escapee, huh.#speaker:venari #portrait:venari_default
I'm Venari, a hunter. Be careful around the forest.#speaker:venari #portrait:venari_default
(Her scar..)#speaker:ragi #portrait:ragi_default
Wanna know how I got this scar, eh?#speaker:venari #portrait:venari_default
I slipped and fell.#speaker:venari #portrait:venari_default
...#speaker:ragi #portrait:ragi_default
(I should give the bread now..)#speaker:ragi #portrait:ragi_default
* [(Hand over Coco's bread.)]
Oh, from Coco is it? Thanks.#speaker:venari #portrait:venari_default
~ doneQuest("village_villager_venari")
-> eol

= loop
Stay safe.#speaker:venari #portrait:venari_default #layout:character
~ talked("venari")
-> eol

=== village_chat_venari_init
= start
Ragi, wasn't it?#speaker:venari #portrait:venari_default #layout:character
I have some advice for you.#speaker:venari #portrait:venari_default
Never confront the creatures directly.#speaker:venari #portrait:venari_default
If you meet one, run away from the area.#speaker:venari #portrait:venari_default
~ doneQuest("village_chat_venari")
-> eol

= loop
Be careful out there.#speaker:venari #portrait:venari_default #layout:character
~ talked("venari")
-> eol

=== village_chat_venari_return
= start
Hey.#speaker:venari #portrait:venari_default #layout:character
Coco told me about your objective.#speaker:venari #portrait:venari_default
I know your dad.#speaker:venari #portrait:venari_default
He went to the forest to do his research.#speaker:venari #portrait:venari_default
Your next clue might be in the forest.#speaker:venari #portrait:venari_default
Don't worry. He always plan ahead.#speaker:venari #portrait:venari_default
Just you being here safe & sound proves it.#speaker:venari #portrait:venari_default
Go tell Feru. She might have something to say.#speaker:venari #portrait:venari_default #layout:character
~ doneQuest("village_chat_return")
-> eol

=== village_leave_venari_init
= start
Make sure to visit us often.#speaker:venari #portrait:venari_default #layout:character
I still have a lot to teach you.#speaker:venari #portrait:venari_default
~ doneQuest("village_leave_venari")
-> eol

= loop
Be careful out there.#speaker:venari #portrait:venari_default #layout:character
~ talked("venari")
-> eol