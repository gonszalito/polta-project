//intro states
VAR state_intro_cutscene = false

// quest states
VAR state_village_intro = false

VAR state_village_bread_init = false
VAR state_village_bread_flour = false
VAR state_village_bread_return = false

VAR state_village_villager_init = false
VAR state_village_villager_feru = false
VAR state_village_villager_venari = false
VAR state_village_villager_aru = false
VAR state_village_villager_guri = false
VAR state_village_villager_boni = false
VAR state_village_villager_all = false
VAR state_village_villager_return = false

VAR state_village_chat_coco = false
VAR state_village_chat_feru = false
VAR state_village_chat_venari = false
VAR state_village_chat_aru = false
VAR state_village_chat_all = false
VAR state_village_chat_return = false

VAR state_village_leave_init = false
VAR state_village_leave_coco = false
VAR state_village_leave_venari = false
VAR state_village_leave_aru = false
VAR state_village_leave_guri = false
VAR state_village_leave_boni = false
VAR state_village_leave_all = false
VAR state_village_leave_quit = false


// indicators
VAR quest_active = "none"
VAR quest_giver_coco = true
VAR quest_giver_feru = false
VAR quest_giver_aru = false
VAR quest_giver_venari = false
VAR quest_giver_guri = false
VAR quest_giver_boni = false
VAR quest_giver_object_flour = false
VAR quest_giver_trigger_quit = false

// npc variables
CONST amount_npc = 6
VAR talked_coco = false
VAR talked_feru = false
VAR talked_venari = false
VAR talked_aru = false
VAR talked_guri = false
VAR talked_boni = false
VAR talked_loop_guri = -1

// helpers
VAR village_intro_choice = 0
VAR village_villager_talked = 0
VAR village_leave_talked = 0
VAR ending_cheat = 0