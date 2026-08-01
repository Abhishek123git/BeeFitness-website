namespace DashboardUI;

public enum ToolsTab
{
    Calculator,
    Standards,
    Workouts
}

public class TabStatus
{
    public bool IsStandardsActive { get; private set; } = false;
    public bool IsWorkoutsActive { get; private set; } = false;

    // Optional event so components can react immediately
    public event Action? OnChange;

    public void SetStandardsActive(bool active)
    {
        IsStandardsActive = active;
        NotifyStateChanged();
    }

    public void SetWorkoutsActive(bool active)
    {
        IsWorkoutsActive = active;
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}


/// <summary>
/// Tracks which tab is active on the Tools page. Replaces the previous
/// IsStandardsActive/IsWorkoutsActive bool pair — that shape let both flags
/// be true (or both false, or Workouts silently mirroring Standards, which is
/// the bug that was in Tools.razor) at once. A single enum makes "which tab
/// is active" a fact that can't contradict itself.
/// </summary>
public class ToolTabStatus
{
    public ToolsTab ActiveTab { get; private set; } = ToolsTab.Calculator;

    public event Action? OnChange;

    public void SetActiveTab(ToolsTab tab)
    {
        if (ActiveTab == tab)
        {
            return; // no-op, avoid redundant re-renders
        }

        ActiveTab = tab;
        OnChange?.Invoke();
    }
}

public interface IPasswordService
{
    Task<bool> SendPasswordAsync(string email);
    bool VerifyPassword(string email, string enteredCode);
}