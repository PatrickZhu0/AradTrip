using System;

namespace behaviac
{
	// Token: 0x020034A9 RID: 13481
	public static class bt_Monster_AI_Heisedadi_Kongbu_Action
	{
		// Token: 0x0601519A RID: 86426 RVA: 0x0065BAD4 File Offset: 0x00659ED4
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Heisedadi/Kongbu_Action");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(44);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node45 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node45();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node.SetId(45);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node46 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node2 = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node46();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.SetId(46);
			sequence.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node48 action_bt_Monster_AI_Heisedadi_Kongbu_Action_node = new Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node48();
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node.SetId(48);
			sequence.AddChild(action_bt_Monster_AI_Heisedadi_Kongbu_Action_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Heisedadi_Kongbu_Action_node.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(39);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node40 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node3 = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node40();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.SetId(40);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node41 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node4 = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node41();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node4.SetId(41);
			sequence2.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node4.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node43 action_bt_Monster_AI_Heisedadi_Kongbu_Action_node2 = new Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node43();
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.SetId(43);
			sequence2.AddChild(action_bt_Monster_AI_Heisedadi_Kongbu_Action_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Heisedadi_Kongbu_Action_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			Sequence sequence3 = new Sequence();
			sequence3.SetClassNameString("Sequence");
			sequence3.SetId(8);
			selector.AddChild(sequence3);
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node28 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node5 = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node28();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node5.SetId(28);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node5);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node5.HasEvents());
			Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node31 condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node6 = new Condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node31();
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node6.SetId(31);
			sequence3.AddChild(condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node6);
			sequence3.SetHasEvents(sequence3.HasEvents() | condition_bt_Monster_AI_Heisedadi_Kongbu_Action_node6.HasEvents());
			Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node33 action_bt_Monster_AI_Heisedadi_Kongbu_Action_node3 = new Action_bt_Monster_AI_Heisedadi_Kongbu_Action_node33();
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.SetId(33);
			sequence3.AddChild(action_bt_Monster_AI_Heisedadi_Kongbu_Action_node3);
			sequence3.SetHasEvents(sequence3.HasEvents() | action_bt_Monster_AI_Heisedadi_Kongbu_Action_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence3.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
