INCLUDE village_globals.ink

->village_feru_main

=== village_feru_main

{
- not state_village_villager_init:
    -> village_default_feru.start
- quest_active == "village_villager":
    {not state_village_villager_feru:
        -> village_villager_feru_init.start
    - else:
        -> village_villager_feru_init.loop
    }
- not state_village_chat_return:
    ~ quest_active = "village_chat"
    {not state_village_chat_feru:
        -> village_chat_feru_init.start
    - else:
        -> village_chat_feru_init.loop
    }
- not state_village_leave_quit:
    ~ quest_active = "village_leave"
    {not state_village_leave_init:
        -> village_leave_feru_init.start
    - else:
        -> village_leave_feru_init.loop
    }
}

=== village_default_feru
= start
Ohoho.#speaker:feru #portrait:feru_happy #layout:character
~ talked("feru")
-> eol

=== village_villager_feru_init
= start
My, my, I've never seen you before, young man.#speaker:feru #portrait:feru_happy #layout:character
You are?#speaker:feru #portrait:feru_default
    My name is Ragi.#speaker:ragi #portrait:ragi_default
Ragi..#speaker:feru #portrait:feru_default
Greetings, my name is Feru.#speaker:feru #portrait:feru_happy
I'm just a little old lady who takes care of the village cats.#speaker:feru #portrait:feru_default
(I should give the bread now..)#speaker:ragi #portrait:ragi_default
* [(Hand over Coco's bread.)]
Ohoho, this is from Coco I suppose?#speaker:feru #portrait:feru_default
She's such a sweet girl for taking care of little 'ol me.#speaker:feru #portrait:feru_happy
Thank you for delivering it to me, Ragi.#speaker:feru #portrait:feru_default
~ doneQuest("village_villager_feru")
-> eol

= loop
A pleasure to meet you.#speaker:feru #portrait:feru_default #layout:character
~ talked("feru")
-> eol

=== village_chat_feru_init
= start
Hello, young man.#speaker:feru #portrait:feru_default #layout:character
You're a lucky one.#speaker:feru #portrait:feru_default
Almost no one has left Polta before, except for a man and you.#speaker:feru #portrait:feru_default
He was a good person.#speaker:feru #portrait:feru_default
He helped the village a lot.#speaker:feru #portrait:feru_default
Coco and her brother were really fond of him.#speaker:feru #portrait:feru_default
You reminded me of him, somehow.#speaker:feru #portrait:feru_default
~ doneQuest("village_chat_feru")
-> eol

= loop
I remember it just like yesterday.#speaker:feru #portrait:feru_default #layout:character
~ talked("feru")
-> eol

=== village_leave_feru_init
= start
Dear young man, do you need something?#speaker:feru #portrait:feru_default #layout:character
(I should tell her what Venari told me.)#speaker:ragi #portrait:ragi_default
* [(Tell her about Dad.)]
I see. So I take it that you'll go inside the forest?#speaker:feru #portrait:feru_default
    Yes.#speaker:ragi #portrait:ragi_default
In that case, take this.#speaker:feru #portrait:feru_default
    You have obtained a small bag!#layout:item
He entrusted this for his son's arrival.#speaker:feru #portrait:feru_default
Make sure to tell the others before departing.#speaker:feru #portrait:feru_default
~ doneQuest("village_leave_init")
-> eol

= loop
We will wait for your return.#speaker:feru #portrait:feru_default #layout:character
~ talked("feru")
-> eol