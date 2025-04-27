<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="row">
      <div class="col-6">
        <a class="navbar-brand" href="#">Javascript Test Movie Catalog</a>
      </div>
      <div class="col-6">
        <input
          class="form-control me-2 ml-auto"
          type="search"
          v-model="search"
          placeholder="Search for Movies"
          aria-label="Search"
        />
      </div>
    </div>
  </nav>

  <div class="text-center" v-if="fetch_loader">
    <vue-loaders scale="1" name="ball-beat" color="blue"></vue-loaders>
  </div>

  <div class="row mt-2" v-else-if="movies?.length > 0">
    <div class="col-4" v-for="movie in movies">
      <div
        class="card w-75"
        role="button"
        @click.prevent="openMovieLink(movie)"
      >
        <img :src="movie.Poster" class="card-img-top" :alt="movie?.Title" />
        <div class="card-body">
          <p class="card-text">
            {{ movie?.Title }}
          </p>
        </div>
      </div>
    </div>
  </div>
  <div v-else class="text-center">
    Please search for a movie name to view data
  </div>
</template>
<script setup>
import { ref, watch, onMounted } from "vue";
import { debounce } from "lodash";
import axios from "axios";

const search = ref("");
const fetch_loader = ref(false);
const movies = ref([]);

onMounted(() => {
  fetch_loader.value = true;
  fetchMovies();
});

const fetchMovies = debounce(() => {
  movies.value = [];
  axios
    .get(
      "http://www.omdbapi.com/?apikey=" +
        import.meta.env.VITE_API_KEY +
        "&s=" +
        search.value
    )
    .then((resp) => {
      console.log("resp?.data?.Response", resp?.data?.Response);
      if (resp?.data?.Response === "True") {
        movies.value = resp?.data?.Search?.slice(0, 3);
      }
      fetch_loader.value = false;
    });
}, 500);

const openMovieLink = (movie) => {
  window.open(movie?.Poster);
};

watch(search, async (search_text) => {
  fetch_loader.value = true;
  fetchMovies();
});
</script>
