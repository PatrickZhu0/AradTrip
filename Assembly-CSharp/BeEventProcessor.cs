using System;
using System.Collections.Generic;

// Token: 0x02004185 RID: 16773
public class BeEventProcessor
{
    // Token: 0x06017048 RID: 94280 RVA: 0x007101D8 File Offset: 0x0070E5D8
    public BeEventHandle AddEventHandler(int eventName, BeEventHandle.Del fn)
    {
        BeEventHandle beEventHandle = new BeEventHandle(eventName, fn, this);
        if (!this.events.ContainsKey(eventName))
        {
            this.events.Add(eventName, new List<BeEventHandle>());
        }
        this.events[eventName].Add(beEventHandle);
        return beEventHandle;
    }

    // Token: 0x06017049 RID: 94281 RVA: 0x00710224 File Offset: 0x0070E624
    public void RemoveEventHandler(int eventName, BeEventHandle.Del fn)
    {
        List<BeEventHandle> list;
        this.events.TryGetValue(eventName, out list);
        if (list != null)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].fn == fn)
                {
                    list.RemoveAt(i);
                }
            }
        }
    }

    // Token: 0x0601704A RID: 94282 RVA: 0x0071027C File Offset: 0x0070E67C
    public void RemoveHandler(BeEventHandle handler)
    {
        if (handler != null && this.events.ContainsKey(handler.eventName))
        {
            List<BeEventHandle> list = this.events[handler.eventName];
            list.RemoveAll((BeEventHandle f) => f == handler);
        }
    }

    // Token: 0x0601704B RID: 94283 RVA: 0x007102E6 File Offset: 0x0070E6E6
    private bool CheckCanRemove(BeEventHandle f)
    {
        return f.canRemove;
    }

    // Token: 0x0601704C RID: 94284 RVA: 0x007102F0 File Offset: 0x0070E6F0
    public void HandleEvent(int eventName, object[] args)
    {
        List<BeEventHandle> list = null;
        this.stackLevel++;
        if (this.stackLevel > Global.TriggerEventStackLevelLimit && this.stackLevel <= Global.MaxStackLevelLogLimit)
        {
            Logger.LogErrorFormat("call event id {0} recurse all out of stack level {1}", new object[]
            {
                eventName,
                this.stackLevel
            });
        }
        if (this.events.TryGetValue(eventName, out list))
        {
            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    if (this.CheckCanRemove(list[i]))
                    {
                        flag = true;
                    }
                    else
                    {
                        list[i].DoFunc(args);
                    }
                }
            }
            if (flag)
            {
                this._RemoveHandleEvent(list);
            }
        }
        this.stackLevel--;
    }

    // Token: 0x0601704D RID: 94285 RVA: 0x007103CF File Offset: 0x0070E7CF
    private void _RemoveHandleEvent(List<BeEventHandle> envList)
    {
        envList.RemoveAll(new Predicate<BeEventHandle>(this.CheckCanRemove));
    }

    // Token: 0x0601704E RID: 94286 RVA: 0x007103E4 File Offset: 0x0070E7E4
    public void ClearAll()
    {
        foreach (int key in this.events.Keys)
        {
            if (this.events.ContainsKey(key) && this.events[key] != null)
            {
                this.events[key].Clear();
            }
        }
        this.events.Clear();
    }

    // Token: 0x0601704F RID: 94287 RVA: 0x0071045B File Offset: 0x0070E85B
    public Dictionary<int, List<BeEventHandle>> GetOldEventHandleList()
    {
        return this.events;
    }

    // Token: 0x06017050 RID: 94288 RVA: 0x00710464 File Offset: 0x0070E864
    public void RemoveDeadHandle()
    {
        foreach (KeyValuePair<int, List<BeEventHandle>> keyValuePair in this.events)
        {
            for (int i = keyValuePair.Value.Count - 1; i >= 0; i--)
            {
                List<BeEventHandle> value = keyValuePair.Value;
                if (value[i] != null && value[i].canRemove)
                {
                    value.RemoveAt(i);
                }
            }
        }
    }

    // Token: 0x04010942 RID: 67906
    private Dictionary<int, List<BeEventHandle>> events = new Dictionary<int, List<BeEventHandle>>();

    // Token: 0x04010943 RID: 67907
    private int stackLevel;
}
