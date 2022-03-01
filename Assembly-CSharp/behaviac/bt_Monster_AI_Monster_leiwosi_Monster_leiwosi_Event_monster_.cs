using System;

namespace behaviac
{
	// Token: 0x020036C3 RID: 14019
	public static class bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi
	{
		// Token: 0x0601559F RID: 87455 RVA: 0x00670DCC File Offset: 0x0066F1CC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Monster_leiwosi/Monster_leiwosi_Event_monster_leiwosi_Shunyi");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(2);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3 action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node = new Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3();
			action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4 condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node = new Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4();
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node.HasEvents());
			Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5 condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2 = new Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5();
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.HasEvents());
			Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node6 condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3 = new Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node6();
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node3.HasEvents());
			Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node7 condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4 = new Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node7();
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node4.HasEvents());
			Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node8 condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5 = new Condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node8();
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node5.HasEvents());
			Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node9 action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2 = new Action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node9();
			action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.SetId(9);
			sequence2.AddChild(action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Monster_leiwosi_Monster_leiwosi_Event_monster_leiwosi_Shunyi_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
