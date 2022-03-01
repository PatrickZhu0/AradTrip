using System;

namespace behaviac
{
	// Token: 0x02003351 RID: 13137
	public static class bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event
	{
		// Token: 0x06014F04 RID: 85764 RVA: 0x0064F164 File Offset: 0x0064D564
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_longziguai_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node6 action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node6();
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node1 condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node1();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node11 action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node11();
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2.SetId(11);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3 action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3();
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node3.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2 action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node4 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node2();
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node4.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_longziguai_Event_node4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
