using System;

namespace behaviac
{
	// Token: 0x020040D2 RID: 16594
	public static class bt_ActionBT
	{
		// Token: 0x060168FA RID: 92410 RVA: 0x006D4F04 File Offset: 0x006D3304
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("ActionBT");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_ActionBT_node1 condition_bt_ActionBT_node = new Condition_bt_ActionBT_node1();
			condition_bt_ActionBT_node.SetClassNameString("Condition");
			condition_bt_ActionBT_node.SetId(1);
			sequence.AddChild(condition_bt_ActionBT_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_ActionBT_node.HasEvents());
			Condition_bt_ActionBT_node3 condition_bt_ActionBT_node2 = new Condition_bt_ActionBT_node3();
			condition_bt_ActionBT_node2.SetClassNameString("Condition");
			condition_bt_ActionBT_node2.SetId(3);
			sequence.AddChild(condition_bt_ActionBT_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_ActionBT_node2.HasEvents());
			Action_bt_ActionBT_node2 action_bt_ActionBT_node = new Action_bt_ActionBT_node2();
			action_bt_ActionBT_node.SetClassNameString("Action");
			action_bt_ActionBT_node.SetId(2);
			sequence.AddChild(action_bt_ActionBT_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_ActionBT_node.HasEvents());
			Condition_bt_ActionBT_node5 condition_bt_ActionBT_node3 = new Condition_bt_ActionBT_node5();
			condition_bt_ActionBT_node3.SetClassNameString("Condition");
			condition_bt_ActionBT_node3.SetId(5);
			sequence.AddChild(condition_bt_ActionBT_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_ActionBT_node3.HasEvents());
			IfElse ifElse = new IfElse();
			ifElse.SetClassNameString("IfElse");
			ifElse.SetId(4);
			sequence.AddChild(ifElse);
			Condition_bt_ActionBT_node6 condition_bt_ActionBT_node4 = new Condition_bt_ActionBT_node6();
			condition_bt_ActionBT_node4.SetClassNameString("Condition");
			condition_bt_ActionBT_node4.SetId(6);
			ifElse.AddChild(condition_bt_ActionBT_node4);
			ifElse.SetHasEvents(ifElse.HasEvents() | condition_bt_ActionBT_node4.HasEvents());
			Action_bt_ActionBT_node7 action_bt_ActionBT_node2 = new Action_bt_ActionBT_node7();
			action_bt_ActionBT_node2.SetClassNameString("Action");
			action_bt_ActionBT_node2.SetId(7);
			ifElse.AddChild(action_bt_ActionBT_node2);
			ifElse.SetHasEvents(ifElse.HasEvents() | action_bt_ActionBT_node2.HasEvents());
			Action_bt_ActionBT_node8 action_bt_ActionBT_node3 = new Action_bt_ActionBT_node8();
			action_bt_ActionBT_node3.SetClassNameString("Action");
			action_bt_ActionBT_node3.SetId(8);
			ifElse.AddChild(action_bt_ActionBT_node3);
			ifElse.SetHasEvents(ifElse.HasEvents() | action_bt_ActionBT_node3.HasEvents());
			sequence.SetHasEvents(sequence.HasEvents() | ifElse.HasEvents());
			WaitforSignal waitforSignal = new WaitforSignal();
			waitforSignal.SetClassNameString("WaitforSignal");
			waitforSignal.SetId(9);
			sequence.AddChild(waitforSignal);
			sequence.SetHasEvents(sequence.HasEvents() | waitforSignal.HasEvents());
			SelectorLoop selectorLoop = new SelectorLoop();
			selectorLoop.SetClassNameString("SelectorLoop");
			selectorLoop.SetId(10);
			sequence.AddChild(selectorLoop);
			sequence.SetHasEvents(sequence.HasEvents() | selectorLoop.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
