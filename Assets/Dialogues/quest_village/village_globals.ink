INCLUDE ../globals.ink
/*
Sequences:
1. village_intro
2. village_bread
3. village_villager
4. village_chat
*/

=== function refreshDialogueNPC
~ talked_coco = false
~ talked_feru = false
~ talked_chef = false
~ talked_venari = false
~ talked_aru = false

=== function queueQuest(quest_name)

{quest_name:
- "village_intro":
    ~ quest_giver = "coco"
    ~ refreshDialogueNPC()
- "village_bread":
    ~ state_village_intro = true
    ~ quest_giver = "coco"
    ~ refreshDialogueNPC()
- "village_villager":
    ~ state_village_bread = true
    ~ quest_giver = "coco"
    ~ refreshDialogueNPC()
- "village_chat":
    ~ state_village_villager = true
    ~ quest_giver = "coco"
    ~ refreshDialogueNPC()
- "village_leave":
    ~ state_village_chat = true
    ~ quest_giver = "feru"
    ~ refreshDialogueNPC()
}

=== eol
-> DONE
