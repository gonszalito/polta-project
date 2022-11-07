INCLUDE village_globals.ink

->village_aru_main

=== village_aru_main

{quest_active == "village_villager":
    {not talked_aru:
        -> village_villager_aru_init.start
    - else:
        -> village_villager_aru_loop.start
    }
- else:
    -> village_default_aru.start
}

=== village_default_aru
= start
You got coins?#speaker:aru #portrait:aru_default #layout:character
-> eol


=== village_villager_aru_init
= start
~ talked_aru = true
~ village_villager_talked++
Heh, fresh eyes! Call me Aru.#speaker:aru #portrait:aru_happy #layout:character
I sell wares, tools, anything!#speaker:aru #portrait:aru_default
I hop from places, you might not see me often here.#speaker:aru #portrait:aru_default
-> eol

=== village_villager_aru_loop
= start
Nice to meet ya, heh.#speaker:aru #portrait:aru_default #layout:character
-> eol