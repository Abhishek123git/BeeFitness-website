window.dashboardCharts = {
    pie: null,
    bar: null,
    line: null,

    renderPie: function (canvasId, labels, data, colors) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (this.pie) this.pie.destroy();
        this.pie = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: colors,
                    borderColor: '#FFFFFF',
                    borderWidth: 2
                }]
            },
            options: {
                cutout: '68%',
                plugins: {
                    legend: { display: false }
                },
                responsive: true,
                maintainAspectRatio: false
            }
        });
    },

    renderBar: function (canvasId, labels, data, color) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (this.bar) this.bar.destroy();
        this.bar = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: color,
                    borderRadius: 4,
                    maxBarThickness: 28
                }]
            },
            options: {
                plugins: { legend: { display: false } },
                scales: {
                    y: { beginAtZero: true, grid: { color: '#EAEFE7' }, ticks: { font: { family: 'IBM Plex Mono', size: 11 } } },
                    x: { grid: { display: false }, ticks: { font: { family: 'IBM Plex Mono', size: 11 } } }
                },
                responsive: true,
                maintainAspectRatio: false
            }
        });
    },

    renderLine: function (canvasId, labels, data, color) {
        const ctx = document.getElementById(canvasId);
        if (!ctx) return;
        if (this.line) this.line.destroy();
        this.line = new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    borderColor: color,
                    backgroundColor: 'transparent',
                    borderWidth: 2,
                    pointRadius: 3,
                    pointBackgroundColor: color,
                    tension: 0.35
                }]
            },
            options: {
                plugins: { legend: { display: false } },
                scales: {
                    y: { grid: { color: '#EAEFE7' }, ticks: { font: { family: 'IBM Plex Mono', size: 11 } } },
                    x: { grid: { display: false }, ticks: { font: { family: 'IBM Plex Mono', size: 11 } } }
                },
                responsive: true,
                maintainAspectRatio: false
            }
        });
    }
};