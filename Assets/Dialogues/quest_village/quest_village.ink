// // // INCLUDE village_boni.ink
// // // INCLUDE village_coco.ink
// // // INCLUDE village_feru.ink
// // // INCLUDE village_aru.ink
// // // INCLUDE village_guri.ink
// // // INCLUDE village_venari.ink

// // // INCLUDE village_object_flour.ink
// // // INCLUDE village_object_bread.ink
// // // INCLUDE village_object_eldertree.ink
// // // INCLUDE village_trigger_quit.ink
// // // INCLUDE village_trigger_lake.ink




// ~queueQuest("village_intro")
// -> main

// === function printQuestGiver
// {quest_giver_coco: [!] Coco}
// {not quest_giver_coco && not talked_coco: [...] Coco}
// {quest_giver_feru: [!] Feru}
// {not quest_giver_feru && not talked_feru: [...] Feru}
// {quest_giver_guri: [!] Guri}
// {not quest_giver_guri && not talked_guri: [...] Guri}
// {quest_giver_aru: [!] Aru}
// {not quest_giver_aru && not talked_aru: [...] Aru}
// {quest_giver_venari: [!] Venari}
// {not quest_giver_venari && not talked_venari: [...] Venari}

// {quest_giver_object_flour: [!] Flour}
// {quest_giver_trigger_quit: [!] Quit}


// === main
// ~ printQuestGiver()

// {state_village_leave_quit: -> END}

// + [Coco]
//     -> village_coco_main
// + [Feru]
//     -> village_feru_main
// + [Guri]
//     -> village_guri_main
// + [Aru]
//     -> village_aru_main
// + [Venari]
//     -> village_venari_main
// + [Objects]
//     + + [Flour]
//         -> village_object_flour_main
//     + + [Bread]
//         -> village_object_bread_main
//     + + [Tree]
//         -> village_object_eldertree_main
// + [Triggers]
//     + + [Quit village]
//         -> village_trigger_quit_main
//     + + [Go to lake]
//         -> village_trigger_lake_main

// === eol
// -> main