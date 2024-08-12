// wwwroot/js/service-worker.js
self.addEventListener('install', function (event) {
    // Perform install steps
    event.waitUntil(
        caches.open('v1').then(function (cache) {
            return cache.addAll([
                '/',
                '/index.cshtml',
                '/css/custom.css',
                '/vendor/bootstrap/css/bootstrap.min.css',
                '/vendor/icons/icofont.min.css',
                '/vendor/jquery/jquery.min.js',
                '/vendor/bootstrap/js/bootstrap.bundle.min.js',
                '/js/custom.js',
                '/img/logo.png',
                '/img/yatrilogo.png'
            ]);
        })
    );
});

self.addEventListener('fetch', function (event) {
    event.respondWith(
        caches.match(event.request).then(function (response) {
            return response || fetch(event.request);
        })
    );
});
