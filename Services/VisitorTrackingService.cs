namespace UnitConverter.Services
{
    public class VisitorTrackingService
    {
        private static int _totalVisits = 0;
        private static readonly Dictionary<string, DateTime> _activeSessions = new();
        private static readonly object _lock = new object();
        private static readonly TimeSpan SessionTimeout = TimeSpan.FromMinutes(5);

        public void RecordVisit(string sessionId)
        {
            lock (_lock)
            {
                _totalVisits++;
                _activeSessions[sessionId] = DateTime.UtcNow;
                CleanupExpiredSessions();
            }
        }

        public void UpdateActivity(string sessionId)
        {
            lock (_lock)
            {
                _activeSessions[sessionId] = DateTime.UtcNow;
                CleanupExpiredSessions();
            }
        }

        public (int TotalVisits, int ActiveUsers) GetStatistics()
        {
            lock (_lock)
            {
                CleanupExpiredSessions();
                return (_totalVisits, _activeSessions.Count);
            }
        }

        private void CleanupExpiredSessions()
        {
            var cutoffTime = DateTime.UtcNow - SessionTimeout;
            var expiredSessions = _activeSessions
                .Where(kvp => kvp.Value < cutoffTime)
                .Select(kvp => kvp.Key)
                .ToList();

            foreach (var sessionId in expiredSessions)
            {
                _activeSessions.Remove(sessionId);
            }
        }
    }
}
