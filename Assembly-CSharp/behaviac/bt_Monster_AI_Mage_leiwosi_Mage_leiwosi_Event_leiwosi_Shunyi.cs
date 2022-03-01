using System;

namespace behaviac
{
	// Token: 0x020035B3 RID: 13747
	public static class bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi
	{
		// Token: 0x06015394 RID: 86932 RVA: 0x006659DC File Offset: 0x00663DDC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Mage_leiwosi/Mage_leiwosi_Event_leiwosi_Shunyi");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(8);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node9 action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node = new Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node9();
			action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.SetClassNameString("Action");
			action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.SetId(9);
			sequence.AddChild(action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.HasEvents());
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			sequence.AddChild(selector);
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(1);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2 condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node = new Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2();
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.SetId(2);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node.HasEvents());
			Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3 condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2 = new Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3();
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.HasEvents());
			Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4 condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3 = new Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4();
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node3.HasEvents());
			Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5 condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4 = new Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5();
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node4.HasEvents());
			Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node6 condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5 = new Condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node6();
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5.SetId(6);
			sequence2.AddChild(condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node5.HasEvents());
			Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node7 action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2 = new Action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node7();
			action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.SetId(7);
			sequence2.AddChild(action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Mage_leiwosi_Mage_leiwosi_Event_leiwosi_Shunyi_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | selector.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
