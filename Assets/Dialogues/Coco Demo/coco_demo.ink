INCLUDE coco.ink

// quest init
{flour_quest_accept == false: -> coco_talk.start | -> flour_quest }


// get flour
// -> flour

// 2 condition: has got flour and hasn't got flour
=== flour_quest ===
{flour == true: -> coco_back.start |-> coco_back.fail }