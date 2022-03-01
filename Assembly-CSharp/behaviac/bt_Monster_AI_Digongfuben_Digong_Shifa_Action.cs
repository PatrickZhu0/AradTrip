using System;

namespace behaviac
{
	// Token: 0x02003252 RID: 12882
	public static class bt_Monster_AI_Digongfuben_Digong_Shifa_Action
	{
		// Token: 0x06014D24 RID: 85284 RVA: 0x00645DA4 File Offset: 0x006441A4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Digongfuben/Digong_Shifa_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.SetId(4);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node5 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node5();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.SetId(5);
			sequence.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(6);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node9 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node9();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3.SetId(9);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3.HasEvents());
			Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3 condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4 = new Condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node3();
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node4.HasEvents());
			Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node10 action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2 = new Action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node10();
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.SetId(10);
			sequence2.AddChild(action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Digongfuben_Digong_Shifa_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
