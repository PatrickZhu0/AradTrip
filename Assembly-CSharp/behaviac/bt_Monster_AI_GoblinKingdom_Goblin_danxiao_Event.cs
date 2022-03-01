using System;

namespace behaviac
{
	// Token: 0x02003310 RID: 13072
	public static class bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event
	{
		// Token: 0x06014E89 RID: 85641 RVA: 0x0064CC24 File Offset: 0x0064B024
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/GoblinKingdom/Goblin_danxiao_Event");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node5 action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node = new Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node5();
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node7 condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node7();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.SetId(7);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node18 action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node18();
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.SetId(18);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.HasEvents());
			Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node0 condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2 = new Condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node0();
			condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node2.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node8 action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node3 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node8();
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node3.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node3.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node3);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node3.HasEvents());
			Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node6 action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node4 = new Action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node6();
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node4.SetClassNameString("Action");
			action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node4.SetId(6);
			sequence.AddChild(action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node4);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_GoblinKingdom_Goblin_danxiao_Event_node4.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
